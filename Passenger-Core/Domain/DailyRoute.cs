﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Passengers.Core.Domain
{
    public class DailyRoute
    {
        private ISet<PassengerNode> _passengerNodes = new HashSet<PassengerNode>();
        public Guid ID { get; protected set; }
        public Route Route { get; protected set; }
        protected DailyRoute()
        {
            ID= new Guid();
        }
        public IEnumerable<PassengerNode> PassengerNodes
        {
            get { return _passengerNodes; }
            set { _passengerNodes = new HashSet<PassengerNode>(value); }
        }
        public void AddPassangerNode(Passenger passenger, Node node)
        {
            var passengerNode = GetPassengerNode(passenger);
            if (passengerNode != null)
            {
                throw new InvalidOperationException($"Node already exists for passenger: '{passenger.UserID}'.");
            }
            _passengerNodes.Add(passengerNode.CreatePassengerNode(node, passenger));

        }

        public void RemovePassengerNode(Passenger passenger, Node node)
        {
            var passengerNode = GetPassengerNode(passenger);
            if (passengerNode == null)
                return;
            _passengerNodes.Remove(passengerNode);
        }
            private PassengerNode GetPassengerNode(Passenger passenger)
                => _passengerNodes.SingleOrDefault(x => x.Passenger.UserID == passenger.UserID);
        }
    } 
