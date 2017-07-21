﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortID = System.UInt16;

namespace PIMSim.General.Ports
{
    public class Port
    {
        private PortID InvalidPortID = PortID.MaxValue;

        /** Descriptive name (for DPRINTF output) */
        private string portName;



        /**
         * A numeric identifier to distinguish ports in a vector, and set
         * to InvalidPortID in case this port is not part of a vector.
         */
        public PortID id;

        /** A reference to the MemObject that owns this port. */
        public Object owner;

        /**
         * Abstract base class for ports
         *
         * @param _name Port name including the owners name
         * @param _owner The MemObject that is the structural owner of this port
         * @param _id A port identifier for vector ports
         */
        public Port(string _name, ref object _owner, PortID _id)
        {
            portName = _name;
            id = _id;
            owner = _owner;
        }

        /**
         * Virtual destructor due to inheritance.
         */
        ~Port() { }

        public virtual void bind(Port port) { }

        public virtual void unbind() { }

        /** Return port name (for DPRINTF). */
        public string name() { return portName; }

        /** Get the port id. */
        public PortID getId() { return id; }


    }
}
