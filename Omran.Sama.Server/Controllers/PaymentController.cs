using Microsoft.AspNetCore.Mvc;
using Omran.Sama.Commen.Constants;
using Omran.Sama.Models;
using Omran.Sama.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omran.Sama.Server.Controllers
{[Route(RouteConstants.PaymentRout)]

    public class PaymentController:Controller
    {
        private PaymentService _service = new PaymentService();

        public PaymentController()
        {
        }


        [HttpGet("[action]")]

        public List<Payment> Load()
        {
            return _service.Load();
        }

        [HttpPost("[Action]")]

        public Payment LoadById(int id)
        {
            return _service.LoadById(id);
        }

        [HttpPost("[Action]")]

        public bool Add([FromBody]Payment payment)
        {
            return _service.Add(payment);
        }

        [HttpPost("[Action]")]

        public bool Remove(int id)
        {
            return _service.Remove(id);
        }
        [HttpPost("[Action]")]

        public bool Update([FromBody]Payment payment)
        {
            return _service.Update(payment);
        }
    }
}
