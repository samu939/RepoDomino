using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;
using System.Threading;

public class RS232 : MonoBehaviour
{

    private SerialPort port;
    private Thread readThread;
    public string output = "";    // From Unity to Arduino
    public string input;
    public bool looping = true;
    public void StartThread()
    {

        port = new SerialPort("COM1", 4800, Parity.None, 8, StopBits.One);
        
        port.Open();
        // Creates and starts the thread
        readThread = new Thread(ReadThreadLoop);
        readThread.Start();

    }

    public bool IsLooping()
    {
        lock (this)
        {
            return true;
        }

    }

    public void ReadThreadLoop()
    {


        while (IsLooping())
        {

            if (output != "")
            {

                string command = output;

                SendData(command);

            }
            

            string result = Pruebaleer();

            if (result != "")
            {
    
                input = result;


            }


        }

    }



    public void Send(string command)
    {
        //Debug.Log(command);

        output = command;

    }


    private void Start()
    {
        StartThread();

    }

    private void Update()
    {



    }

    public void SendData(string data)
    {
        output = "";
        port.WriteLine(data);
        port.BaseStream.Flush();
        output = "";
    }

    public string ReadData()
    {
        string data = port.ReadLine();

        return data;
    }

    public string Pruebaleer()
    {

        string data = null;

        while (port.BytesToRead > 0)
        {
            data += (char)port.ReadByte();
        }
        port.BaseStream.Flush();
        //Debug.Log(data);
        
        

        return input + data;

    }

    private void OnDisable()
    {
        readThread.Abort();
        port.Close();
    }

    private void OnApplicationQuit()
    {

        readThread.Abort();
        port.Close();

    }
}
