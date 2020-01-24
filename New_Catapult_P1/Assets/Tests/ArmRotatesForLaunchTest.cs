﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    [TestFixture]
    public class ArmRotatesForLaunchTest
    {
        public LaunchControls armScript;
        GameObject catapult = new GameObject();


        [SetUp]
        public void Setup()
        {
            catapult.AddComponent<Rigidbody2D>();

            //armScript = catapult.GetComponent<LaunchControls>();
        }

        [TearDown]
        public void TearDown()
        {
            Object.Destroy(armScript);
        }

        // A Test behaves as an ordinary method
        [UnityTest]
        public IEnumerator TestArmRotation()
        {

            float initialZRotation = catapult.GetComponent<Rigidbody2D>().transform.localRotation.z;

            if (catapult.transform.rotation.z >= -0.86f)
            {
                catapult.transform.Rotate(0.0f, 0.0f, -1);
                
            }

            yield return new WaitForSeconds(0.05f);

           float NewZRotation = catapult.GetComponent<Rigidbody2D>().transform.localRotation.z;

           Assert.Less(NewZRotation, initialZRotation);

        }

    }
}
