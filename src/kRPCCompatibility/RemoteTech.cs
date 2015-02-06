﻿using System;
using ExternalRemoteTech = RemoteTech;

namespace KRPCCompatibility
{
  internal class RemoteTechAvailable : RemoteTech.IRemoteTechAPI {
    internal RemoteTechAvailable() {
        ExternalRemoteTech.API.API.HasFlightComputer (new Guid ());
    }
    public bool HasFlightComputer(Guid id) {
      return ExternalRemoteTech.API.API.HasFlightComputer(id);
    }
    public void AddSanctionedPilot(Guid id, Action<FlightCtrlState> autopilot) {
      ExternalRemoteTech.API.API.AddSanctionedPilot(id, autopilot);
    }
    public void RemoveSanctionedPilot(Guid id, Action<FlightCtrlState> autopilot) {
      ExternalRemoteTech.API.API.RemoveSanctionedPilot(id, autopilot);
    }
    public bool HasAnyConnection(Guid id) {
      return ExternalRemoteTech.API.API.HasAnyConnection(id);
    }
    public bool HasConnectionToKSC(Guid id) {
      return ExternalRemoteTech.API.API.HasConnectionToKSC(id);
    }
    public double GetShortestSignalDelay(Guid id) {
      return ExternalRemoteTech.API.API.GetShortestSignalDelay(id);
    }
    public double GetSignalDelayToKSC(Guid id) {
      return ExternalRemoteTech.API.API.GetSignalDelayToKSC(id);
    }
    public double GetSignalDelayToSatellite(Guid a, Guid b) {
      return ExternalRemoteTech.API.API.GetSignalDelayToSatellite(a, b);
    }
  }

  internal class RemoteTechNotInstalled : RemoteTech.IRemoteTechAPI {
    public bool HasFlightComputer(Guid id) {
      return false;
    }
    public void AddSanctionedPilot(Guid id, Action<FlightCtrlState> autopilot) {}
    public void RemoveSanctionedPilot(Guid id, Action<FlightCtrlState> autopilot) {}
    public bool HasAnyConnection(Guid id) {
      return false;
    }
    public bool HasConnectionToKSC(Guid id) {
      return false;
    }
    public double GetShortestSignalDelay(Guid id) {
      return 0d;
    }
    public double GetSignalDelayToKSC(Guid id) {
      return 0d;
    }
    public double GetSignalDelayToSatellite(Guid a, Guid b) {
      return 0d;
    }
  }
}