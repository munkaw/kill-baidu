using System;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.ServiceProcess;
using System.Management;
using System.Drawing;

namespace Kill_Baidu
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process[] prs = Process.GetProcesses();
            listBox2.Items.Clear();
            listBox1.Items.Clear();
            label1.Text = "...";
           
            try
            {
                foreach (Process pr in prs)      //  วนเพื่ออ่านรายการใน Process ทั้งหมด
                {
                    if (pr.ProcessName == "BavTray")    // -----------------  เช็คว่า Baidu Antivirus ทำงานอยู่หรือไม่
                    {
                        pr.Kill();
                        listBox1.Items.Add("kill process Baidu Antivirus Success.");
                        label1.Text = "kill process Baidu Antivirus Success."; //สถาณะ แบบเดี่ยว
                    }
                    else
                    {
                        label1.Text = "No Baidu Anti Virus is running."; //สถาณะ แบบเดี่ยว
                        //listBox1.Items.Add("No Baidu Anti Virus is running."); //สถาณะแบบ list
                    }

                    //-----------------------------------------------------------------------

                    if (pr.ProcessName == "pcfaster")    // ------------- เช็คว่า Baidu PC Faster ทำงานอยู่หรือไม่
                    {
                        pr.Kill();
                        listBox1.Items.Add("kill process Baidu PC Fasster Success."); //สถานะแบบ list
                        label1.Text = "kill process Baidu Antivirus Success."; //สถาณะ แบบเดี่ยว
                    }
                    else
                    {
                        label1.Text = "No Baidu PC Faster is running."; //สถาณะ แบบเดี่ยว
                        //listBox1.Items.Add("No Baidu PC Faster is running.");
                    }

                    listBox2.Items.Add(pr.ProcessName); //รายชื่อโปรแกรมที่ทำงาน
                }
            }
            catch
            {
                label1.Text = "เกิดข้อผิดพลาด !! ดำเนินการไม่สำเร็จ ";
            }// end try catch
            
          
        }

        public  void StopService(string serviceName, int timeoutMilliseconds)
        {
            ServiceController service = new ServiceController(serviceName);
            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
            }
            catch
            {
                label1.Text = "ไม่สามารถปิด service "+ serviceName + " ได้";
            }
        }
    }
}
