using System;
using System.Collections.Generic;
using System.Text;

namespace MiniSuperPF_YustinA.Models
{
    public class ServiceStatus

    {

        public ServiceStatus()
        {
           // Services = new HashSet<Service>();
        }

        public int ServiceStatusId { get; set; }
        public string ServiceStatusDescription { get; set; } = null!;

      //  public virtual ICollection<Service> Services { get; set; }
    }
}
