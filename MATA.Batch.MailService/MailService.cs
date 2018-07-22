using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace MATA.Batch.MailService
{
    public partial class MailService : ServiceBase
    {
        readonly IUnityContainer container;

        public MailService()
        {
            InitializeComponent();

            container = new UnityContainer();
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }
    }
}
