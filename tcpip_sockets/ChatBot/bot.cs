using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ChatBot
{
    public class Bot
    {
        public delegate void SendMsgDelegate(string msg);
        private SendMsgDelegate _sendMsg;
        private List<string> _phrases;
        private bool _isOn;
        public Bot(SendMsgDelegate sendMsg)
        {
            _phrases = new List<string>();
            _sendMsg = sendMsg;
        }
        public void ReadWords(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                _phrases.Clear();
                while (!sr.EndOfStream)
                {
                    _phrases.Add(sr.ReadLine());
                }
            }
        }
        public void BotOn()
        {
            if (_phrases.Count == 0)
                throw new ApplicationException("Empty bot base! Load bot base first!");

            _isOn = true;

            Thread botThread = new Thread(new ThreadStart(BotWorkingThread));
            botThread.Start();
        }
        private void BotWorkingThread()
        {
            Random rnd = new Random(new Guid().GetHashCode());

            double elapsedTime = 0;
            while (_isOn)
            {
                if (elapsedTime == 0)
                {
                    elapsedTime = rnd.Next(1000000, 4000000);

                    int index = rnd.Next(0, _phrases.Count - 1);
                    _sendMsg(_phrases[index]);
                }

                --elapsedTime;
            }
        }
        public void BotOff()
        {
            _isOn = false;
        }
    }
}
