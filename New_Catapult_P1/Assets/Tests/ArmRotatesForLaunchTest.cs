using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{

    public class ArmRotatesForLaunchTest
    {
        public LaunchControls armScript;
        GameObject catapult;

        [SetUp]
        public void Setup()
        {
            catapult = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Full_Catapult"));
            armScript = catapult.GetComponent<LaunchControls>();
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

            armScript.isrotating = true;

            yield return new WaitForSeconds(0.05f);

            float NewZRotation = catapult.GetComponent<Rigidbody2D>().transform.localRotation.z;

            Assert.Less(NewZRotation, initialZRotation);

        }

    }
}
