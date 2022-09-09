using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Azure.Devices.Client;
using CommandLine;
using System.IO;
using System.Net;
using System.Security.Policy;
using System.Net.Http;

namespace GetPCStat
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            lb_log_message.Items.Clear();

            find_connection_string();
        }


        private void find_connection_string()
        {
            string mock_devices_github = "https://raw.githubusercontent.com/duochh/IoTFloor1/main/output/mock-devices.json";

            WebClient client = new WebClient();
            Stream data = client.OpenRead(mock_devices_github);
            StreamReader reader = new StreamReader(data);

            string string_json = reader.ReadToEnd();

            data.Close();
            reader.Close();

            string root_folder = Environment.CurrentDirectory;
            string json_path = root_folder + "/mock_devices/mock_devices.json";

            File.WriteAllText(json_path, string_json);

            if (get_connection_string(json_path) == "None")
            {
                MessageBox.Show("Connection String not found for this computer. Please import mock-devices.json file manually.");
            }
            else
            {
                tb_connection_string.Text = get_connection_string(json_path);
                bt_connect_to_IoT.Enabled = true;

                lb_log_message.Items.Add("Connection String found.");
            }
        }


        private void bt_import_connection_string_csv_Click(object sender, EventArgs e)
        {
            OpenFileDialog file_dialog = new OpenFileDialog();

            if (file_dialog.ShowDialog() == DialogResult.OK)
            {
                if (!file_dialog.FileName.Contains(".json"))
                {
                    MessageBox.Show("Please import mock-devices.json file manually.");

                    return;
                }

                if (get_connection_string(file_dialog.FileName) == "None")
                {
                    MessageBox.Show("Connection String not found for this computer. Please import mock-devices.json file manually.");

                    return;
                }
                else
                {
                    tb_connection_string.Text = get_connection_string(file_dialog.FileName);
                    bt_connect_to_IoT.Enabled = true;

                    lb_log_message.Items.Add("Connection String found.");
                }

                tb_connection_string.Text = get_connection_string(file_dialog.FileName);
            }
        }


        private async void bt_connect_to_IoT_Click(object sender, EventArgs e)
        {
            if (!is_application_running_in_time())
            {
                lb_log_message.Items.Add("Fixed connection time to IoT only from 8.00 AM to 8.00 PM.");
                lb_log_message.Items.Add("Please retry connection between 8.00 AM to 8.00 PM.");

                return;
            }

            string deviceConnectionString = tb_connection_string.Text;

            if (deviceConnectionString == "")
            {
                lb_log_message.Items.Add("Connection String should not be empty.");

                return;
            }
            else
            {
                lb_log_message.Items.Add("Connecting to IoT.");

                DeviceClient s_deviceClient = DeviceClient.CreateFromConnectionString(deviceConnectionString);

                if (s_deviceClient == null)
                {
                    lb_log_message.Items.Add("Cannot connect to IoT. Please recheck.");

                    return;
                }
                else
                {
                    lb_log_message.Items.Add("Connect to IoT successfully.");
                }

                bt_disconnect_to_iot.Enabled = true;

                await ConnectToIoT(s_deviceClient, deviceConnectionString);
            }
        }

        
        private void bt_disconnect_to_iot_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }


        private string get_connection_string(string connection_string_json)
        {
            string pc_name = System.Environment.MachineName;

            string[] lines = System.IO.File.ReadAllLines(connection_string_json);

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].ToUpper();
                string upper_line = lines[i].ToUpper();
                bool has_deviceID = line.Contains("DEVICEID") ? true : false;
                bool has_pcName = upper_line.Contains(pc_name.ToUpper()) ? true : false;

                if (has_deviceID && has_pcName)
                {
                    for (int j = i; j < lines.Length; j++)
                    {
                        if (lines[j].Contains("connectionString"))
                        {
                            string connection_string = lines[j].Split(":")[1];

                            return connection_string.Trim();
                        }
                    }

                }
            }

            return "None";
        }


        private async Task ConnectToIoT(DeviceClient s_deviceClient, string deviceConnectionString)
        {
            // Hide application in the background
            Hide();

            ManagementObjectSearcher searcher;
            string pc_name = "";
            string cpu_name = "";
            double cpu_usage = 0.0;
            double cpu_temperature = 0.0;
            double memory_free = 0.0;
            double memory_max = 0.0;
            double memory_usage = 0.0;
            string gpu_name = "";
            double gpu_usage = 0.0;
            List<string> running_processes = new List<string>();
            bool is_pc_active = false;
            bool get_pc_name = false;
            bool get_pc_info = false;
            bool get_pc_usage = false;
            bool get_pc_temperature = false;
            bool get_memory = false;
            bool get_gpu_info = false;
            bool get_gpu = false;

            
            while (true)
            {            
                if (!is_application_running_in_time())
                {
                    lb_log_message.Items.Add("Out of time to connect to IoT. The connection is only from 8.00 AM to 8.00 PM");

                    break;
                }

                is_pc_active = false;
                get_pc_name = false;
                get_pc_info = false;
                get_pc_usage = false;
                get_pc_temperature = false;
                get_memory = false;
                get_gpu_info = false;
                get_gpu = false;


                // PC Name
                try
                {
                    pc_name = System.Environment.MachineName;

                    gb_pc_name.Text = pc_name;
                    Debug.WriteLine("PC Name: " + pc_name);

                    get_pc_name = true;
                }
                catch
                {
                    pc_name = "";
                    lb_log_message.Items.Add("Error when getting PC Name. Try to run with administrator.");
                }


                // CPU Information
                try
                {
                    searcher = new ManagementObjectSearcher("select * from Win32_Processor");

                    var cpuInfo = searcher.Get().Cast<ManagementObject>().FirstOrDefault();

                    //CPU.ID = (string)cpu["ProcessorId"];
                    //CPU.Socket = (string)cpu["SocketDesignation"];
                    cpu_name = (string)cpuInfo["Name"];
                    //CPU.Description = (string)cpu["Caption"];
                    //CPU.AddressWidth = (ushort)cpu["AddressWidth"];
                    //CPU.DataWidth = (ushort)cpu["DataWidth"];
                    //CPU.Architecture = (CPU.CpuArchitecture)(ushort)cpu["Architecture"];
                    //CPU.SpeedMHz = (uint)cpu["MaxClockSpeed"];
                    //CPU.BusSpeedMHz = (uint)cpu["ExtClock"];
                    //CPU.L2Cache = (uint)cpu["L2CacheSize"] * (ulong)1024;
                    //CPU.L3Cache = (uint)cpu["L3CacheSize"] * (ulong)1024;
                    //CPU.Cores = (uint)cpu["NumberOfCores"];
                    //CPU.Threads = (uint)cpu["NumberOfLogicalProcessors"];

                    lb_cpu_name.Text = cpu_name;
                    Debug.WriteLine("Cpu Name: " + cpu_name);

                    get_gpu_info = true;
                }
                catch
                {
                    cpu_name = "";
                    lb_log_message.Items.Add("Error when getting PC Information. Try to run with administrator.");
                }


                // CPU Usage
                try
                {
                    searcher = new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfOS_Processor");

                    var cpuTimes = searcher.Get().Cast<ManagementObject>().Select(m => new
                    {
                        Name = m["Name"],
                        Usage = m["PercentProcessorTime"]
                    }).FirstOrDefault();

                    if (cpuTimes == null) throw new Exception("Can't recive informacion about cpu usage.");

                    cpu_usage = (ulong)cpuTimes.Usage;

                    lb_cpu_usage.Text = cpu_usage.ToString() + " %";
                    Debug.WriteLine("Cpu Usage: " + cpu_usage + " %");

                    get_pc_usage = true;
                }
                catch
                {
                    cpu_usage = 999.9;
                    lb_log_message.Items.Add("Error when getting PC Usage. Try to run with administrator.");
                }


                // CPU Temperature
                try
                {
                    searcher = new ManagementObjectSearcher(@"root\WMI", "SELECT * FROM MSAcpi_ThermalZoneTemperature");

                    foreach (ManagementObject obj in searcher.Get())
                    {
                        Double temperature = Convert.ToDouble(obj["CurrentTemperature"].ToString());
                        temperature = (temperature - 2732) / 10.0;
                        Debug.WriteLine(temperature);
                    }

                    var cpuTemp = searcher.Get().Cast<ManagementObject>().Select(m => new
                    {
                        Temperature = m["CurrentTemperature"]
                    }).Max();

                    if (cpuTemp == null) throw new Exception("Can't recive informacion about cpu temperature.");

                    cpu_temperature = Math.Round(Convert.ToDouble(cpuTemp.Temperature.ToString()), 1);
                    cpu_temperature = (cpu_temperature - 2732.0) / 10.0;

                    lb_cpu_temperature.Text = cpu_temperature.ToString() + " °C";
                    Debug.WriteLine("Cpu Temperature: " + cpu_temperature + " °C");

                    get_pc_temperature = true;
                }
                catch
                {
                    cpu_temperature = 999.9;
                    lb_log_message.Items.Add("Error when getting PC Temperature. Try to run with administrator.");
                }


                // Memory
                try
                {
                    searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");

                    var memory = searcher.Get().Cast<ManagementObject>().Select(m => new
                    {
                        TotalVisibleMemorySize = m["TotalVisibleMemorySize"],
                        FreeMemory = m["FreePhysicalMemory"]
                    }).FirstOrDefault();

                    if (memory == null) throw new Exception("Can't recive informacion about memory usage.");

                    memory_free = Math.Round((ulong)memory.FreeMemory / 1024.0 / 1024.0, 1);
                    memory_max = Math.Round((ulong)memory.TotalVisibleMemorySize / 1024.0 / 1024.0, 1);
                    memory_usage = Math.Round((memory_max - memory_free) / (float)memory_max * 100, 1);

                    lb_memory_usage.Text = (Math.Round(memory_max - memory_free, 1)).ToString() + " / " + memory_max + " GB";
                    Debug.WriteLine("Memory: " + (memory_max - memory_free) + " / " + memory_max + " GB");
                    Debug.WriteLine("Memory Usage : " + memory_usage + " %");

                    get_memory = true;
                }
                catch
                {
                    memory_usage = 999.9;
                    lb_log_message.Items.Add("Error when getting Memory. Try to run with administrator.");
                }


                // GPU Information
                try
                {
                    searcher = new ManagementObjectSearcher("select * from Win32_VideoController ");

                    var gpuInfo = searcher.Get().Cast<ManagementObject>().Select(m => new
                    {
                        VideoController = m["Description"]
                    }).FirstOrDefault();

                    if (gpuInfo == null) throw new Exception("Can't recive informacion about gpu information.");

                    gpu_name = gpuInfo.VideoController.ToString();

                    lb_gpu_name.Text = gpu_name;
                    Debug.WriteLine("GPU Name: " + gpu_name);

                    get_gpu_info = true;
                }
                catch
                {
                    gpu_name = "";
                    lb_log_message.Items.Add("Error when getting GPU Information. Try to run with administrator.");
                }


                // GPU
                try
                {
                    searcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");

                    string graphicsCard = string.Empty;
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        if (obj["CurrentBitsPerPixel"] != null && obj["CurrentHorizontalResolution"] != null)
                        {
                            graphicsCard = obj["Name"].ToString();
                        }
                    }

                    var category = new PerformanceCounterCategory("GPU Engine");
                    var counterNames = category.GetInstanceNames();

                    var gpuCounters = counterNames
                                        .Where(counterName => counterName.EndsWith("engtype_3D"))
                                        .SelectMany(counterName => category.GetCounters(counterName))
                                        .Where(counter => counter.CounterName.Equals("Utilization Percentage"))
                                        .ToList();

                    gpuCounters.ForEach(x => x.NextValue());

                    Thread.Sleep(1000);

                    var result = gpuCounters.Sum(x => x.NextValue());
                    gpu_usage = Math.Round(Convert.ToDouble(result), 1);

                    lb_gpu_usage.Text = gpu_usage.ToString() + " %";
                    Debug.WriteLine("GPU Usage: " + gpu_usage + " %");

                    get_gpu = true;
                }
                catch
                {
                    gpu_usage = 999.9;
                    lb_log_message.Items.Add("Error when getting GPU Information. Try to run with administrator.");
                }


                // Running Processes
                string[] running_process = new string[10]{"null","null", "null", "null", "null", "null", "null", "null", "null", "null"};
                int num_process = -1;

                try
                {
                    Process[] processes = Process.GetProcesses();
                    double process_memory = 0.0;
                    lb_larggest_processes.Items.Clear();
                    running_processes.Clear();

                    foreach (Process process in processes)
                    {
                        process_memory = process.WorkingSet64 / 1024.0 / 1024.0;

                        if (process_memory < 1024.0) // Filter which process is using less than 1GB of memory
                        {
                            continue;
                        }

                        //Console.WriteLine("PID:  " + process.Id);
                        running_processes.Add(process.ProcessName);
                        lb_larggest_processes.Items.Add(process.ProcessName);
                        Debug.WriteLine("Larggest process name above 1GB of memory: " + process.ProcessName);

                        num_process++;

                        try
                        {
                            running_process[num_process] = process.ProcessName;
                        }
                        catch
                        {
                            continue;
                        }
                    }  
                }
                catch
                {
                    lb_log_message.Items.Add("Error when getting Running Processes. Try to run with administrator.");
                }


                // Check if PC is active
                if (!get_pc_name && !get_pc_info && !get_pc_usage && !get_pc_temperature && !get_memory && !get_gpu_info && !get_gpu)
                {
                    is_pc_active = false;
                }
                else
                {
                    is_pc_active = true;
                }


                // Create JSON message
                string messageBody = JsonSerializer.Serialize(
                    new
                    {
                        isPCActive = is_pc_active,
                        pcName = pc_name,
                        cpuName = cpu_name,
                        cpuUsage = cpu_usage,
                        cpuTemperature = cpu_temperature,
                        memoryUsage = (Math.Round(memory_max - memory_free, 1)).ToString() + " / " + memory_max.ToString() + " GB",
                        gpuName = gpu_name,
                        gpuUsage = gpu_usage,
                        runningProcess1 = running_process[0],
                        runningProcess2 = running_process[1],
                        runningProcess3 = running_process[2]
                    });

                using var message = new Microsoft.Azure.Devices.Client.Message(Encoding.ASCII.GetBytes(messageBody))
                {
                    ContentType = "application/json",
                    ContentEncoding = "utf-8",
                };

                await s_deviceClient.SendEventAsync(message);


                // Add message
                lb_log_message.Items.Add("Send a message at " + DateTime.Now);
                

                // After a message has been sent, delay for 120 seconds
                await Task.Delay(1000);
            }

            return;
        }


        private bool is_application_running_in_time()
        {
            int hour = DateTime.Now.Hour;

            if (hour < 8 || hour > 20)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
        }
    }
}
