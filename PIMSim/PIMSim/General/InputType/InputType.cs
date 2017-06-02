﻿#region Reference

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace SimplePIM.General
{
    /// <summary>
    /// Abstract Inupt Class
    /// </summary>
    public abstract class InputType
    {
        #region Static Varibles

        public static readonly UInt64 NULL = UInt64.MaxValue;

        #endregion

        #region Public Varibles

        public UInt64 cycle;
        public abstract UInt64 Length();

        #endregion
    }
}
