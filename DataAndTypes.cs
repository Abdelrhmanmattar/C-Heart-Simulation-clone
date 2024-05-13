﻿using System;
using System.Collections.Generic;

namespace HeartSim.DataAndTypes
{
  // Node
  public struct Position
  {
    public float X, Y;
  }

  public enum NodeStateIndexEnum { Rest = 1, ERP = 2, RRP = 3 }

  public enum PathTerminalEnum { Entry = 1, Exit = 2 }

  public enum AVnessEnum { AV = 1, NonAV = 2 }

  public struct PathTerminalPair
  {
    public int PathIdx;
    public PathTerminalEnum Terminal;
  }

  public struct NodeParameters
  {
    public string NodeName;
    public NodeStateIndexEnum NodeStateIndex;
    public int TERPCurrent;
    public int TERPDefault;
    public int TRRPCurrent;
    public int TRRPDefault;
    public int TrestCurrent;
    public int TrestDefault;
    public bool Activation;
    public int TerpMin;
    public int TerpMax;
    public int IndexOfPathActivateTheNode;
    public AVnessEnum AVness;
    public List<PathTerminalPair> ConnectedPaths;
    public Position NodePos;
  }

  // Path
  public enum PathStateIndexEnum
  {
    Idle = 1,
    AntegradeConduction = 2,
    Retrograde = 3,
    Conflict = 4,
    Double = 5
  }

  public struct PathParameters
  {
    public string PathName;
    public PathStateIndexEnum PathStateIndex;
    public int EntryNodeIndex;
    public int ExitNodeIndex;
    public int AmplitudeFactor;
    public float ForwardSpeed;
    public float BackwardSpeed;
    public float ForwardTimerCurrent;
    public float ForwardTimerDefault;
    public float BackwardTimerCurrent;
    public float BackwardTimerDefault;
    public float PathLength;
    public float PathSlope;
  }

  public class EpAvnrtDataGen
  {
    // Nodes Data
    public readonly List<string> NodeNames = new List<string>
    {
        "SA", "CT", "AV", "OS", "His_p", "His_m", "His_d",
        "Bach", "LA_a", "LA", "RBB_m", "RBB", "LBB_m", "LBB",
        "RVA", "LVA", "RV_m", "RV", "LV_m", "LV", "CT_a",
        "RA_a", "RA", "SEP_RV_m", "SEP_RV", "SEP_LV_m", "SEP_LV", "CS_LV",
        "CS_LA", "slow_b", "slow_a", "fast", "fast_b",
    };

    public readonly List<List<int>> NodeIntParameters = new List<List<int>>
  {
    {1, 220, 220, 10, 20, 700, 700, 0, 150, 300, 0, 2},
    {1, 220, 220, 120, 120, 9999, 9999, 0, 150, 360, 0, 2},
    {1, 320, 320, 250, 250, 9999, 9999, 0, 350, 230, 0, 1},
    {1, 320, 320, 120, 120, 9999, 9999, 0, 100, 200, 0, 2},
    {1, 320, 320, 120, 120, 9999, 9999, 0, 330, 440, 0, 2},
    {1, 320, 320, 120, 120, 9999, 9999, 0, 330, 440, 0, 2},
    {1, 320, 320, 120, 120, 9999, 9999, 0, 330, 440, 0, 2},
    {1, 320, 320, 120, 120, 9999, 9999, 0, 150, 360, 0, 2},
    {1, 320, 320, 120, 120, 9999, 9999, 0, 150, 360, 0, 2},
    {1, 320, 320, 120, 120, 9999, 9999, 0, 150, 360, 0, 2},
    {1, 320, 320, 120, 120, 9999, 9999, 0, 330, 440, 0, 2},
    {1, 320, 320, 120, 120, 9999, 9999, 0, 330, 440, 0, 2},
    {1, 320, 320, 120, 120, 9999, 9999, 0, 330, 440, 0, 2},
    {1, 320, 320, 120, 120, 9999, 9999, 0, 330, 440, 0, 2},
    {1, 320, 320, 120, 120, 9999, 9999, 0, 180, 290, 0, 2},
    {1, 320, 320, 120, 120, 9999, 9999, 0, 180, 290, 0, 2},
    {1, 320, 320, 120, 120, 9999, 9999, 0, 180, 290, 0, 2},
    {1, 320, 320, 120, 120, 9999, 9999, 0, 180, 290, 0, 2},
    {1, 320, 320, 120, 120, 9999, 9999, 0, 180, 290, 0, 2},
    {1, 320, 320, 120, 120, 9999, 9999, 0, 180, 290, 0, 2},
    {1, 220, 220, 120, 120, 9999, 9999, 0, 150, 360, 0, 2},
    {1, 320, 320, 120, 120, 9999, 9999, 0, 150, 360, 0, 2},
    {1, 320, 320, 120, 120, 9999, 9999, 0, 150, 360, 0, 2},
    {1, 320, 320, 120, 120, 9999, 9999, 0, 150, 300, 0, 2},
    {1, 320, 320, 120, 120, 9999, 9999, 0, 150, 300, 0, 2},
    {1, 320, 320, 120, 120, 9999, 9999, 0, 150, 300, 0, 2},
    {1, 320, 320, 120, 120, 9999, 9999, 0, 150, 300, 0, 2},
    {1, 320, 320, 120, 120, 9999, 9999, 0, 150, 300, 0, 2},
    {1, 320, 320, 120, 120, 9999, 9999, 0, 150, 300, 0, 2},
    {1, 320, 320, 200, 200, 9999, 9999, 0, 250, 150, 0, 1},
    {1, 320, 320, 300, 300, 9999, 9999, 0, 250, 150, 0, 1},
    {1, 320, 320, 10, 10, 9999, 9999, 0, 500, 380, 0, 1},
    {1, 320, 320, 10, 10, 9999, 9999, 0, 500, 380, 0, 1},
  };

    public readonly List<Position> NodePositions = new List<Position>
  {
    {135.5, 295.5}, {134.5, 161.5}, {170.5, 216.5}, {165.5, 263.5},
    {204.5, 248.5}, {236.5, 250.5}, {262.5, 220.5}, {245.5, 344.5},
    {313.5, 349.5}, {338.5, 325.5}, {304.5, 161.5}, {382.5, 127.5},
    {319.5, 172.5}, {392.5, 149.5}, {394.5, 113.5}, {410.5, 144.5},
    {280.5, 96.5},  {187.5, 147.5}, {398.5, 235.5}, {358.5, 303.5},
    {112.5, 243.5}, {175.5, 295.5}, {198.5, 269.5}, {286.5, 149.5},
    {207.5, 228.5}, {327.5, 189.5}, {254.5, 263.5}, {312.5, 316.5},
    {296.5, 334.5}, {151.5, 213.5}, {150.5, 243.5}, {167.5, 243.5},
    {168.5, 230.5},
  };

    // Path Data
    public readonly List<string> PathNames = new List<string>
  {
    "SA_CT_a",   "CT",       "slow_AV", "SA_OS",    "fast_AV", "SA_Bach",
      "Bach_LA_a", "LA",       "AV_His",  "His_p",    "His_d",   "His_RBB",
      "His_LBB",   "RBB",      "LBB",     "RBB_RV",   "LBB_LV",  "RV_LV",
      "RV_m",      "LV_m",     "RV",      "LV",       "SA_RA_a", "RA",
      "SEP_RV",    "SEP_RV_m", "SEP_LV",  "SEP_LV_m", "CS_LV",   "CS_LA",
      "slow",      "OS_slow",  "OS_fast", "fast"
  };

    public readonly List<List<int>> PathIntParameters = new List<List<int>>
  {
    {1, 1, 21, 10},  {1, 21, 2, 10},  {1, 30, 3, 5},   {1, 1, 4, 5},
      {1, 33, 3, 5},   {1, 1, 8, 5},    {1, 8, 9, 10},   {1, 9, 10, 10},
      {1, 3, 5, 2},    {1, 5, 6, 2},    {1, 6, 7, 2},    {1, 7, 11, 2},
      {1, 7, 13, 2},   {1, 11, 12, 2},  {1, 13, 14, 2},  {1, 12, 15, 10},
      {1, 14, 16, 10}, {1, 15, 16, 10}, {1, 15, 17, 10}, {1, 16, 19, 10},
      {1, 17, 18, 10}, {1, 19, 20, 10}, {1, 1, 22, 10},  {1, 22, 23, 10},
      {1, 24, 25, 10}, {1, 15, 24, 10}, {1, 26, 27, 10}, {1, 16, 26, 10},
      {1, 27, 28, 10}, {1, 23, 29, 5},  {1, 31, 30, 10}, {1, 4, 31, 10},
      {1, 4, 32, 10},  {1, 32, 33, 10},
  };

    public readonly List<List<float>> PathFloatParameters = new List<List<float>>
  {
    {1, 1, 57, 57, 57, 57, 56.859475903318, 2.260869565217391},
    {1, 1, 85, 85, 85, 85, 84.8999411071645, -3.727272727272727},
    {1, 1, 19, 19, 19, 19, 19.235384061671343, 1.5277777777777777},
    {1, 1, 44, 44, 44, 44, 43.86342439892262, -1.0666666666666667},
    {1, 1, 47, 47, 47, 47, 14.142135623730951, -7},
    {3.0105024497581794, 3.0105024497581794, 40, 40, 40, 40,
      120.42009799032718, 0.44545454545454544},
    {1, 1, 68, 68, 68, 68, 68.18357573492314, 0.07352941176470588},
    {1, 1, 35, 35, 35, 35, 34.655446902326915, -0.96},
    {1, 1, 47, 47, 47, 47, 46.69047011971501, 0.9411764705882353},
    {2, 2, 16, 16, 16, 16, 32.0624390837628, 0.0625},
    {2, 2, 20, 20, 20, 20, 39.698866482558415, -1.1538461538461537},
    {2, 2, 36, 36, 36, 36, 72.42237223399962, -1.4047619047619047},
    {2, 2, 37, 37, 37, 37, 74.51845409024533, -0.8421052631578947},
    {4.25440947723653, 4.25440947723653, 20, 20, 20, 20, 85.0881895447306,
      -0.4358974358974359},
    {3.8268786236304906, 3.8268786236304906, 20, 20, 20, 20,
      76.53757247260981, -0.3150684931506849},
    {1, 1, 18, 18, 18, 18, 18.439088914585774, -1.1666666666666667},
    {1, 1, 19, 19, 19, 19, 18.681541692269406, -0.2777777777777778},
    {2, 2, 17, 17, 17, 17, 34.88552708502482, 1.9375},
    {5.7630287176102115, 5.7630287176102115, 20, 20, 20, 20,
      115.26057435220423, 0.14912280701754385},
    {4.589389937671455, 4.589389937671455, 20, 20, 20, 20, 91.7877987534291,
      -7.583333333333333},
    {5.303300858899107, 5.303300858899107, 20, 20, 20, 20, 106.06601717798213,
      -0.5483870967741935},
    {3.944616584663204, 3.944616584663204, 20, 20, 20, 20, 78.89233169326408,
      -1.7},
    {1, 1, 40, 40, 40, 40, 40, 0},
    {1, 1, 35, 35, 35, 35, 34.713109915419565, -1.1304347826086956},
    {2, 2, 56, 56, 56, 56, 111.72287142747452, -1},
    {2, 2, 57, 57, 57, 57, 113.84199576606166, -0.3333333333333333},
    {2, 2, 52, 52, 52, 52, 103.9471019317037, -1.0136986301369864},
    {2, 2, 47, 47, 47, 47, 94.41398201537736, -0.5421686746987951},
    {2, 2, 39, 39, 39, 39, 78.56844150166147, 0.9137931034482759},
    {2, 2, 59, 59, 59, 59, 117.5967686630887, 0.6632653061224489},
    {0.09, 0.09, 330, 330, 330, 330, 30.01666203960727, -30},
    {2, 2, 13, 13, 13, 13, 25, 1.3333333333333333},
    {2, 2, 10, 10, 10, 10, 20.09975124224178, -10},
    {2, 2, 7, 7, 7, 7, 13.038404810405298, -13},
  };

    // EGM Data
    public readonly List<string> EgmSingleNames = new List<string>
  {
    "HRA1",  "HRA2", "HRA3", "HRA4",  "CS1",    "CS2",
      "CS3",   "CS4",  "CS5",  "His_d", "His_m1", "His_m2",
      "His_p", "RVA1", "RVA2", "RVA3",  "RVA4",
  };

    public readonly List<int> EgmSingleIntParameters = new List<int>
  {
    1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17,
  };

    public readonly List<string> EgmDoubleNames = new List<string>
  {
    "HRA_d", "HRA_m", "HRA_p", "CS1,2", "CS2,3", "CS3,4", "CS4,5",
      "His_d", "His_m", "His_p", "RVA_d", "RVA_m", "RVA_p",
  };

    public readonly List<Tuple<int, int>> EgmDoubleIntParameters = new List<Tuple<int, int>>
  {
    {1, 2},   {2, 3},   {3, 4},   {5, 6},   {6, 7},   {7, 8},   {8, 9},
      {10, 11}, {11, 12}, {12, 13}, {14, 15}, {15, 16}, {16, 17},
  };

    // Probe Data
    public readonly List<string> ProbeNames = new List<string>
  {
    "HRA1",  "HRA2", "HRA3", "HRA4",  "CS1",    "CS2",
      "CS3",   "CS4",  "CS5",  "His_d", "His_m1", "His_m2",
      "His_p", "RVA1", "RVA2", "RVA3",  "RVA4",
  };

    public readonly List<List<int>> ProbeIntParameters = new List<List<int>>
  {
    {23, 24}, {1, 23, 24},      {1, 23},  {1},      {29, 30}, {29, 30},
      {29, 30}, {29, 30},         {29, 30}, {24, 25}, {24, 25}, {10, 24, 25},
      {24, 25}, {14, 16, 19, 26}, {14, 26}, {14, 26}, {14, 26},
  };

    public readonly List<Position> ProbePositions = new List<Position>
  {
    {168.5, 280.5}, {152.5, 284.5}, {136.5, 282.5}, {131.5, 266.5},
      {305.5, 322.5}, {289.5, 313.5}, {272.5, 305.5}, {254.5, 296.5},
      {237.5, 286.5}, {249.5, 227.5}, {231.5, 236.5}, {213.5, 243.5},
      {196.5, 249.5}, {366.5, 119.5}, {351.5, 127.5}, {333.5, 137.5},
      {314.5, 146.5},
  };

    // Pace Data
    public readonly List<string> ComponentNames = new List<string>
  {
    "LRI",
      "AVI",
      "ARP",
      "VRP",
  };

    public readonly List<List<int>> PaceIntParameters = new List<List<int>>
  {
     {1, 1000, 1000, 0},
      {1, 150, 150, 0},
      {1, 150, 150, 0},
      {1, 320, 320, 0},
  };
  }
}