using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LightBulbMVC.Models
{
    public class LightBulbModel
    {
        /// <summary>
        /// processes the result of which light bulbs will stay on at the end
        /// </summary>
        /// <param name="peopleColl"></param>
        /// <param name="bulbsColl"></param>
        /// <returns></returns>
        public LightBulbViewModel ProcessResult(IEnumerable<int> peopleColl, IEnumerable<int> bulbsColl)
        {
            Dictionary<int, bool> result = new Dictionary<int, bool>();
            bool bulbState = false;
            
            // first person turns on all lights
            foreach (int b in bulbsColl)
                result.Add(b, true);


            // from second person onward, update the status for all multiples of the person number
            for (int p = 2; p <= peopleColl.Count(); p++)
            {
                for (int i = 1; i <= bulbsColl.Count(); i++)
                {
                    if (i >= p && i % p == 0)
                    {
                        bulbState = result[i - 1];
                        result[i - 1] = !bulbState;
                    }
                }
            }

            // add to view model
            Dictionary<int, bool> bulbsOn = result.Where(p => p.Value == true).ToDictionary(p => p.Key + 1, p => p.Value);
            LightBulbViewModel lightBulbVM = new LightBulbViewModel();
            lightBulbVM.Results = bulbsOn;

            return lightBulbVM;
        }
    }

    public class LightBulbViewModel
    {
        public Dictionary<int, bool> Results;
    }
}