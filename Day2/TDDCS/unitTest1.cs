using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
 
namespace TemplateEngine
{
    public class TemplateEngine
    {
        private string template;
        private Dictionary<string, string> variables = new Dictionary<string, string>();
 
        public string Evaluate()
        {
            string fullname = template;
            foreach (var variable in variables)
            {
                fullname = fullname.Replace("{" + variable.Key + "}", variable.Value);
            }
 
            return fullname;
        }
 
        public void setTempalate(string template)
        {
            this.template = template;
        }
 
        public void setVariable(string name , string value)
        {
            variables.Add(name, value);
        }
 
    }
 
}
using System.Net.Security;
using NUnit.Framework;
 
namespace TemplateEngine.Tests
{
    public class TempleEngineTests
    {
        [SetUp]
        public void Setup()
        {
        }
 
        [TestCase("Ptajwal", "H M", "Hello Prajwal H M")]
        [TestCase("Naveen","N", "Hello Naveen N")]
 
 
        public void ShouldEvaluateForSingleVariable(string value1, string value2, string expectedValue)
        {
            //Arrange
            TemplateEngine templateEngine = new TemplateEngine();
            templateEngine.setTempalate("Hello {firstName} {secondName}");
            templateEngine.setVariable("firstName", value1);
            templateEngine.setVariable("secondName", value2);
 
            //ACT
            string result = templateEngine.Evaluate();
 
            //Assert
            Assert.That(result, Is.EqualTo(expectedValue));
        }
    }
}
