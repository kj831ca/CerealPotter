using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using ZedGraph;

namespace CerealPotter
{
    public partial class Form1 : Form
    {
        SerialPort _serialPort;
        Dictionary<string, RollingPointPairList> graphLists;
        bool isPlotting = false;
        object lockUpdate = new object();
        SerialParser parser;
        bool isSerialPortSelectChange = false;
        public Form1()
        {
            InitializeComponent();
            GetSerialPortList();
            this.FormClosed += Form1_FormClosed;
            _serialPort = new SerialPort();
            graphLists = new Dictionary<string, RollingPointPairList>();
            zedGraphControl1.GraphPane.Title.Text = "Cereal Potter Graph";
            zedGraphControl1.GraphPane.XAxis.Type = AxisType.Date;
            zedGraphControl1.GraphPane.XAxis.Title.Text = "Time";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "Level";
            parser = new SerialParser();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isSerialPortSelectChange)
                Properties.Settings.Default.Save();
        }

        private void GetSerialPortList()
        {
            string[] serialList = SerialPort.GetPortNames();
            string selectPort = Properties.Settings.Default.serial_port;
            foreach (string s in serialList)
            {
                this.comboBoxAvailableSerial.Items.Add(s);
                if (selectPort == s)
                    this.comboBoxAvailableSerial.SelectedItem = s;
            }
        }
        private void buttonConnect_Click(object sender, EventArgs e)
        {

            if (comboBoxAvailableSerial.SelectedIndex == -1) return;
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
                buttonConnect.Text = "Connect";
                return;
            }

            string portSelect = comboBoxAvailableSerial.SelectedItem.ToString();
            //Make application remember what comport user was using last time.
            if(portSelect != Properties.Settings.Default.serial_port)
            {
                isSerialPortSelectChange = true;
                Properties.Settings.Default.serial_port = portSelect;
            }
            _serialPort.PortName = portSelect;
            _serialPort.BaudRate = 115200;
            _serialPort.Open();
            _serialPort.DataReceived += _serialPort_DataReceived;
            buttonConnect.Text = "Disconnect";
        }
        private delegate void UpdateTextboxDel(TextBox txtBox, string msg);
        private void UpdateTextBox(TextBox txtBox, string msg)
        {
            if (txtBox.InvokeRequired)
            {
                this.Invoke(new UpdateTextboxDel(UpdateTextBox), new object[] { txtBox, msg });
                return;
            }
            txtBox.Text = msg;
        }
        
        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            try
            {
                string dataRead = _serialPort.ReadLine();
                UpdateTextBox(textBoxReceive, dataRead);
                lock (lockUpdate)
                {
                    if (isPlotting)
                    {
                        Dictionary<string, double> records = parser.ParsingMatch(dataRead);
                        if (records.Count == 0) return;
                        UpdataSignal(records);

                    }
                }

            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

        }
        Color[] colorList = {Color.Red, Color.Blue, Color.Green, Color.Brown, Color.Yellow, Color.Purple,
        Color.Orange, Color.Pink}; //Hope we have enough color for graph .. :P
        int color_idx = 0;
        private RollingPointPairList AddCurve(string name)
        {
            RollingPointPairList pp = new RollingPointPairList(10000);
            zedGraphControl1.GraphPane.AddCurve(name, pp, colorList[color_idx++], SymbolType.None);
            graphLists.Add(name, pp);
            return pp;
        }
        private void UpdataSignal(Dictionary<string,double> signals)
        {
            XDate x = new XDate(DateTime.Now);
            foreach (string key in signals.Keys)
            {
                if (graphLists.ContainsKey(key))
                {
                    RollingPointPairList ppList = graphLists[key];
                    ppList.Add(x, signals[key]);
                }
                else //Create the new curve 
                {
                    RollingPointPairList p = AddCurve(key);
                    p.Add(x, signals[key]);
                }
                UpdateGraph();
            }
        }


        private delegate void UpdateGraphDel();
        private void UpdateGraph()
        {
            if (zedGraphControl1.InvokeRequired)
            {
                this.Invoke(new UpdateGraphDel(UpdateGraph));
                return;
            }
            zedGraphControl1.GraphPane.AxisChange();
            zedGraphControl1.Invalidate();
        }
        private void buttonStartPlot_Click(object sender, EventArgs e)
        {
            //lock (lockUpdate)
            {
                if (!isPlotting)
                {
                    isPlotting = false;
                    zedGraphControl1.GraphPane.CurveList.Clear();
                    graphLists.Clear();
                    color_idx = 0;
                    UpdateGraph();
                    isPlotting = true;
                    buttonStartPlot.Text = "Stop Plotting";
                }
                else
                {
                    isPlotting = false;
                    buttonStartPlot.Text = "Start Plotting";
                }
            }
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            string text = textBoxReceive.Text;
            parser.ParsingMatch(text);
        }
    }
    
}
