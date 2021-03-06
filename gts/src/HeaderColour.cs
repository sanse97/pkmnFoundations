﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PkmnFoundations.GTS
{
    public class HeaderColour : System.Web.UI.Control
    {
        public HeaderColour()
        {
            CssClass = null;
            this.PreRender += HeaderColour_PreRender;
        }

        private void HeaderColour_PreRender(object sender, EventArgs e)
        {
            PkmnFoundations.GTS.MasterPage master = Page.Master as PkmnFoundations.GTS.MasterPage;
            if (master == null) return;

            master.HeaderCssClass = CssClass;
        }

        protected override void LoadViewState(object savedState)
        {
            HeaderColourViewState state = (HeaderColourViewState)savedState;

            this.CssClass = state.CssClass;

            base.LoadViewState(state.ControlViewState);
        }

        protected override object SaveViewState()
        {
            HeaderColourViewState state = new HeaderColourViewState();

            state.CssClass = this.CssClass;
            state.ControlViewState = base.SaveViewState();

            return state;
        }

        public String CssClass { get; set; }

        [Serializable()]
        private struct HeaderColourViewState
        {
            public object ControlViewState;
            public String CssClass;
        }
    }
}