using System;
using System.Collections.Generic;
using System.Text;

namespace MiniSuperPF_YustinA.Models
{
  public class Email
    {
        public string SendTo { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        public bool SendEmail()
        {
            bool R = false;

            try
            {
                if (!string.IsNullOrEmpty(SendTo) &&
                    !string.IsNullOrEmpty(Subject) &&
                    !string.IsNullOrEmpty(Message))
                {
                    System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();

                    
                }
            }
            catch (Exception)
            {
                throw;
            }
            return R;
        }
    }
}
