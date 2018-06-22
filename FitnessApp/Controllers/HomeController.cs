using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using AutoMapper;
using FitnessAPP.DATA;

namespace FitnessAPP.Controllers
{


    public class HomeController : Controller
    {
        private IConfiguration Configuration;
        private readonly IMapper mapper;
        private readonly IActivitiesRepository activitiesRepository;

        public HomeController(
                                    IMapper _mapper,
                                    IConfiguration Configuration,
                                   IActivitiesRepository activitiesRepository
                                  )
        {
            this.activitiesRepository = activitiesRepository;
            mapper = _mapper;
            this.Configuration = Configuration;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {

            return View();
        }

        public IActionResult Activity()
        {
            IEnumerable<Activity> activities = activitiesRepository.GetActivities().Select(mapper.Map<Activity>); ;
            return View();
        }
    }
}
