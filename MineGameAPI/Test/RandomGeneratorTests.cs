using RandomClasses;

namespace Testing
{
    [TestClass]
    public class RandomGeneratorTests
    {
        RandomGenerator? randomGenerator1;
        RandomGenerator? randomGenerator2;
        public void givenARandomGeneratorInstance()
        {
            randomGenerator1 = new RandomGenerator();
        }

        public void givenTwoRandomGeneratorInstances()
        {
            randomGenerator1 = new RandomGenerator();
            randomGenerator2 = new RandomGenerator();
        }

        public void thenTheTwoRandomGeneratorInstancesHaveDifferentSeeds()
        {
            Assert.AreNotEqual(randomGenerator1!.seed, randomGenerator2!.seed);
        }
        public void thenCallingGetNumberOnGeneratorUsingMaximumEqualToMinimumPlusOneReturnsMinimum()
        {
            // Generate the number 100 times as
            // the generator could return the correct number by coincidence instead of being properly contrained.
            // This minimises the chances of that happening.
            for (int i = 0; i < 100; i++) 
            {
                Assert.AreEqual(randomGenerator1!.getRandom(5, 6), 5);
            }
        }

        [TestMethod]
        public void RandomGeneratorInstancesHaveUniqueSeed()
        {
            givenTwoRandomGeneratorInstances();
            thenTheTwoRandomGeneratorInstancesHaveDifferentSeeds();
        }

        [TestMethod]
        public void RandomlyGeneratedNumbersUsingMinimumAndMaximumAreWithinBounds()
        {
            givenARandomGeneratorInstance();
            thenCallingGetNumberOnGeneratorUsingMaximumEqualToMinimumPlusOneReturnsMinimum();
        }
    }
}
