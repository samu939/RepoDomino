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
    public string output="";    // From Unity to Arduino
    public string input;
    public bool looping = true;
    public void StartThread()
    {

        
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
        port = new SerialPort("COM2", 9600, Parity.None, 8, StopBits.One);
        
        port.Open();
        
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
                
                input=result;
                
                
            }
            
        }
       
    }



    public void Send(string command)
    {
        //Debug.Log(command);

        output=command;
        
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
        output="";
        port.WriteLine(data);
        port.BaseStream.Flush();
        output="";
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
        
        return input+data;
        
    }

    private void OnDisable()
    {
        port.Close();
        readThread.Abort();
    }

    private void OnClose()
    {
        port.Close();
        readThread.Abort();
    }
}
