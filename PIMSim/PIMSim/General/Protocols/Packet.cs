﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ID = System.UInt64;
using Address = System.UInt64;
using System.Diagnostics;
using PIMSim.APIs;

namespace PIMSim.General.Protocols
{
    public class Packet : Request, Printable
    {
        public Command cmd;

        private byte[] data;

        public ID packet_id;

        public ID sub_packet_id;

        public bool sub_packet = false;

        public Request req; //point to orginal requests;

        private Address addr;

        /// True if the request targets the secure memory space.
        private bool _isSecure;

        /// The size of the request or transfer.
        private byte size;

        private List<bool> bytesValid;

        /**
         * The extra delay from seeing the packet until the header is
         * transmitted. This delay is used to communicate the crossbar
         * forwarding latency to the neighbouring object (e.g. a cache)
         * that actually makes the packet wait. As the delay is relative,
         * a 32-bit unsigned should be sufficient.
         */
        public UInt32 headerDelay;

        /**
         * Keep track of the extra delay incurred by snooping upwards
         * before sending a request down the memory system. This is used
         * by the coherent crossbar to account for the additional request
         * delay.
         */
        UInt32 snoopDelay;

        /**
         * The extra pipelining delay from seeing the packet until the end of
         * payload is transmitted by the component that provided it (if
         * any). This includes the header delay. Similar to the header
         * delay, this is used to make up for the fact that the
         * crossbar does not make the packet wait. As the delay is
         * relative, a 32-bit unsigned should be sufficient.
         */
        UInt32 payloadDelay;


        /// Return the string name of the cmd field (for debugging and
        /// tracing).
        public string cmdString() { return cmd.toString(); }

        /// Return the index of this command.
        public int cmdToIndex() { return cmd.toInt(); }

        public bool isRead() { return cmd.isRead(); }
        public bool isWrite() { return cmd.isWrite(); }
        public bool isUpgrade() { return cmd.isUpgrade(); }
        public bool isRequest() { return cmd.isRequest(); }
        public bool isResponse() { return cmd.isResponse(); }
        public bool needsWritable()
        {
            // we should never check if a response needsWritable, the
            // request has this flag, and for a response we should rather
            // look at the hasSharers flag (if not set, the response is to
            // be considered writable)
            Debug.Assert(isRequest());
            return cmd.needsWritable();
        }
        public bool needsResponse() { return cmd.needsResponse(); }
        public bool isInvalidate() { return cmd.isInvalidate(); }
        public bool isEviction() { return cmd.isEviction(); }
        public bool fromCache() { return cmd.fromCache(); }
        public bool isWriteback() { return cmd.isWriteback(); }
        public bool hasData() { return cmd.hasData(); }
        public bool hasRespData()
        { 
            return cmd.hasData();
        }
        public bool isLLSC() { return cmd.isLLSC(); }
        public bool isError() { return cmd.isError(); }
        public bool isPrint() { return cmd.isPrint(); }
        public bool isFlush() { return cmd.isFlush(); }

        public void Print()
        {

        }

    }
}
