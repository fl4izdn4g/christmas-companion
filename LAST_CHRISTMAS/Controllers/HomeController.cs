using LAST_CHRISTMAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAST_CHRISTMAS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var fileContents = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/data.csv"));
            string[] elements = fileContents.Split(new char[] { ';' });

            HomeIndexViewModel model = new HomeIndexViewModel();
            for(int i = 0; i < elements.Length; i++)
            {
                if(elements[i] == "PAWEL")
                {
                    model.PawelUnlocked = true;
                }
                if(elements[i] == "ANNA")
                {
                    model.AniaUnlocked = true;
                }
                if(elements[i] == "JUSTYNA") {
                    model.JustynaUnlocked = true;
                }
                if(elements[i] == "MARCIN")
                {
                    model.MarcinUnlocked = true;
                }
            }

            return View(model);
        }

        private bool IsAnswered(string code)
        {
            var fileContents = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/data.csv"));
            string[] elements = fileContents.Split(new char[] { ';' });

            return elements.Contains(code);
        }

        private void SetAnswer(string code)
        {
            var fileContents = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/data.csv"));
            string[] elements = fileContents.Split(new char[] { ';' });
            var list = elements.ToList();
            list.Add(code);

            string toFile = String.Join(";", list.ToArray());

            System.IO.File.WriteAllText(Server.MapPath("~/App_Data/data.csv"), toFile);
        }


        Dictionary<string, MemberViewModel> memberPages = new Dictionary<string, MemberViewModel>()
        {
            {
                "ANNA",
                new MemberViewModel()
                {
                    Answer = "UC Santa Cruz",
                    PageIdentity = "zspcddk",
                    MemberTitle = "Anno",
                    Letter = "lhop" // c      w -> druk
                }
            },
            {
                "JUSTYNA",
                new MemberViewModel()
                {
                    Answer = "Danny Elfman",
                    PageIdentity = "mospsgg",
                    MemberTitle = "Justyno",
                    Letter = "gndu" // i     k -> druk
                }
            },
            {
                "MARCIN",
                new MemberViewModel()
                {
                    Answer = "czerwony",
                    PageIdentity = "tszmnbo",
                    MemberTitle = "Marcinie",
                    Letter = "irzk" // s     o -> druk
                }
            },
            {
                "PAWEL",
                new MemberViewModel()
                {
                    Answer = "Niemiecka Intendentura Wojskowa",
                    PageIdentity = "adhidye",
                    MemberTitle = "Pawle",
                    Letter = "aefm" // y    p -> druk
                }
            }
        };

        Dictionary<int, string> musicBands = new Dictionary<int, string>()
        {
            {0, "Slade" },
            {1, "Bob Dylan" },
            {2, "John Lennon & Yoko Ono" },
            {3, "Mariah Carey" },
            {4, "Wham!" },
            {5, "Low" },
            {6, "Bobby Helms" },
            {7, "Destiny’s Child" },
            {8, "Paul McCartney" },
            {9, "Vince Guaraldi Trio" },
        };

        /*
         * tjlcdgr - galeria
         * zlnublk - wszyscy
           adhidye - Paweł
           mospsgg - Justyna
           zspcddk - Ania
           tszmnbo - Marcin
         */

        //galeria
        public ActionResult tjlcdgr()
        {
            return View();
        }

        //wszyscy
        //
        public ActionResult zlnublk()
        {
            Random rand = new Random();
            musicBands = musicBands.OrderBy(x => rand.Next())
              .ToDictionary(item => item.Key, item => item.Value);

            ViewBag.Bands = musicBands;
            return View();
        }

        //Paweł
        //
        public ActionResult adhidye()
        {
            if(IsAnswered("PAWEL"))
            {
                memberPages["PAWEL"].IsSuccess = true;
            }

            return View(memberPages["PAWEL"]);
        }

        [HttpPost]
        public ActionResult adhidye(MemberViewModel model)
        {
            if (model.GivenAnswer.ToLower() == memberPages["PAWEL"].Answer.ToLower())
            {
                if(!IsAnswered("PAWEL"))
                {
                    SetAnswer("PAWEL");
                }
                memberPages["PAWEL"].IsSuccess = true;
            }
            else
            {
                memberPages["PAWEL"].IsError = true;
            }
            return View(memberPages["PAWEL"]);
        }

        //Justyna
        //
        public ActionResult mospsgg()
        {
            if (IsAnswered("JUSTYNA"))
            {
                memberPages["JUSTYNA"].IsSuccess = true;
            }

            return View(memberPages["JUSTYNA"]);
        }

        [HttpPost]
        public ActionResult mospsgg(MemberViewModel model)
        {
            if (model.GivenAnswer.ToLower() == memberPages["JUSTYNA"].Answer.ToLower())
            {
                if (!IsAnswered("JUSTYNA"))
                {
                    SetAnswer("JUSTYNA");
                }
                memberPages["JUSTYNA"].IsSuccess = true;
            }
            else
            {
                memberPages["JUSTYNA"].IsError = true;
            }
            return View(memberPages["JUSTYNA"]);
        }


        //Ania
        //
        public ActionResult zspcddk()
        {
            if (IsAnswered("ANNA"))
            {
                memberPages["ANNA"].IsSuccess = true;
            }

            return View(memberPages["ANNA"]);
        }

        [HttpPost]
        public ActionResult zspcddk(MemberViewModel model)
        {
            if (model.GivenAnswer.ToLower() == memberPages["ANNA"].Answer.ToLower())
            {
                if (!IsAnswered("ANNA"))
                {
                    SetAnswer("ANNA");
                }
                memberPages["ANNA"].IsSuccess = true;
            }
            else
            {
                memberPages["ANNA"].IsError = true;
            }
            return View(memberPages["ANNA"]);
        }

        //Marcin
        //
        public ActionResult tszmnbo()
        {
            if (IsAnswered("MARCIN"))
            {
                memberPages["MARCIN"].IsSuccess = true;
            }

            return View(memberPages["MARCIN"]);
        }

        [HttpPost]
        public ActionResult tszmnbo(MemberViewModel model)
        {
            if (model.GivenAnswer.ToLower() == memberPages["MARCIN"].Answer.ToLower())
            {
                if (!IsAnswered("MARCIN"))
                {
                    SetAnswer("MARCIN");
                }
                memberPages["MARCIN"].IsSuccess = true;
            }
            else
            {
                memberPages["MARCIN"].IsError = true;
            }
            return View(memberPages["MARCIN"]);
        }
    }
}