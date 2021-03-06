﻿using NUnit.Framework;
using Messiah.Utility;
using Messiah.Editor;
using UnityEngine;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

static class UtilityTest {
  [Test]
  public static void RunCmdTest() {
    Utility.RunCmd(Constant.ExcelToJsonExe);
  }

  [Test]
  public static void ExcelToJsonTest() {
    Utility.GenerateJson("t.xlsx");
  }

  [Test]
  public static void PathTest() {
    Debug.Log(Path.GetFullPath("fuck"));
  }

  [Test]
  public static void ParallelForTest() {
    Task.Factory.StartNew(() => {
      Parallel.For(0, 10, (i) => {
        Debug.Log(i);
      });
    });
    Debug.Log("!!!!");
  }

  [Test]
  public static void JsonTest() {
    var d = JsonUtility.FromJson<Dictionary<string, string>>("{\"a\":\"1\", \"b\": \"2\"}");
    Debug.Log(d.Count);
  }

  [Test]
  public static void CSGeneratorTest() {
    Utility.ModifyCSharpFile(
      "C:/Users/yifuwang.TENCENT/Documents/GitHub/Messiah/Assets/1. Data/1. Config/2. CSharp/you.cs",
    "C:/Users/yifuwang.TENCENT/Documents/GitHub/Messiah/Assets/1. Data/1. Config/1. Json/you.json");
  }
}