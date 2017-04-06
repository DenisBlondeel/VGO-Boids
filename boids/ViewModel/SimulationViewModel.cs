﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Mathematics;
using System.ComponentModel;
using Microsoft.Practices.ServiceLocation;
using Service;
using System.Windows.Input;

namespace ViewModel
{
    public class SimulationViewModel : INotifyPropertyChanged
    {

        private Simulation sim;

        public Simulation Sim
        {
            get
            {
                return sim;
            }
            set
            {
                sim = value;
            }
        }

        public SimulationViewModel()
        {
            this.sim = new Simulation();

            this.sim.Species[0].CreateBoid(new Vector2D(50, 50));
            this.sim.Species[0].CreateBoid(new Vector2D(250, 250));
            this.sim.Species[0].CreateBoid(new Vector2D(500, 500));
            this.sim.Species[0].CreateBoid(new Vector2D(750, 750));
            this.sim.Species[0].CreateBoid(new Vector2D(1000, 1000));
            this.sim.Species[0].CreateBoid(new Vector2D(1200, 1200));
            this.sim.Species[1].CreateBoid(new Vector2D(150, 150));
            var timer = ServiceLocator.Current.GetInstance<ITimerService>();
            timer.Tick += Timer_Tick;
            timer.Start(new TimeSpan(0, 0, 0, 0, 15));
        }

        private void Timer_Tick(ITimerService obj)
        {
            sim.Update(0.01);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
