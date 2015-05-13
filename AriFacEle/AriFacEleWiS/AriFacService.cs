using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;

namespace AriFacEleWiS
{
    public partial class AriFacService : ServiceBase
    {
        Timer myTimer;

        public AriFacService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
            CntWiS.myOnStart(args);
            InitTimer();
        }

        protected override void OnStop()
        {
            base.OnStop();
            CntWiS.myOnStop();
        }

        #region Timer control

        public void InitTimer()
        {
            //Timer para el control del tiempo entre llamadas.
            myTimer = new System.Timers.Timer();
            //Intervalo de tiempo entre llamadas.
            myTimer.Interval = 3000;
            //Evento a ejecutar cuando se cumple el tiempo.
            myTimer.Elapsed += new System.Timers.ElapsedEventHandler(myTimer_Elapsed);
            //Habilitar el Timer.
            myTimer.Start();
        }
        
        public void myTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //Detiene el Timer
            myTimer.Stop();
            //llama al Servicio
            CntWiS.CopyFiles();
            //habilita el Timer nuevamente.
            myTimer.Start();
        }
        #endregion
    }
}
