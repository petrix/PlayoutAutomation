﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TAS.Common;
using TAS.Server.Interfaces;

namespace TAS.Client.ViewModels
{
    public class EventPanelMovieViewmodel: EventPanelRundownElementViewmodelBase
    {
        public EventPanelMovieViewmodel(IEvent ev, EventPanelViewmodelBase parent) : base(ev, parent) { }
    }
}
