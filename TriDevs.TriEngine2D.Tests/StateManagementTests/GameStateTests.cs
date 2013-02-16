using System.Linq;
using NUnit.Framework;
using TriDevs.TriEngine2D.Interfaces;
using TriDevs.TriEngine2D.StateManagement;

namespace TriDevs.TriEngine2D.Tests.StateManagementTests
{
    [TestFixture]
    public class GameStateTests
    {
        private class TestState : GameState
        {
            
        }

        private class FooComponent : IGameComponent
        {
            public bool Enabled { get; set; }
            
            public string Test = "Foo";

            public void Update()
            {
                
            }

            public void Enable()
            {
                
            }

            public void Disable()
            {
                
            }
        }

        private class BarComponent : IGameComponent
        {
            public bool Enabled { get; set; }

            public string Test = "Bar";

            public void Update()
            {
                
            }

            public void Enable()
            {
                
            }

            public void Disable()
            {
                
            }
        }

        [Test]
        public void TestAddComponent()
        {
            var state = new TestState();
            Assert.False(state.HasComponent(typeof (FooComponent)));
            var comp = state.AddComponent(new FooComponent());
            Assert.True(state.HasComponent(comp));
        }

        [Test]
        public void TestRemoveComponent()
        {
            var state = new TestState();
            var fooComp1 = new FooComponent();
            var fooComp2 = new FooComponent();
            state.AddComponent(fooComp1);
            state.AddComponent(fooComp2);
            Assert.AreEqual(state.GetAllComponents(typeof (FooComponent)).Count(), 2);
            state.RemoveAllComponents(typeof (FooComponent));
            Assert.IsEmpty(state.GetAllComponents());
            fooComp1.Test = "This is not foo!";
            state.AddComponent(fooComp1);

            // This is ok in this code, since we only have a FooComponent in the GameState
            // at the moment. In production code we should probably cast c to FooComponent
            // and make sure it's not null before checking the Test field.
            state.RemoveAllComponents(c => ((FooComponent) c).Test == "Foo");
            
            // The component shouldn't be removed, as we changed the Test field from the
            // default value of Foo, thus making the above predicate function find nothing.
            Assert.IsNotEmpty(state.GetAllComponents());

            state.RemoveAllComponents();
            Assert.IsEmpty(state.GetAllComponents());

            var barComp = state.AddComponent(new BarComponent());
            state.RemoveComponent(barComp);
            Assert.IsEmpty(state.GetAllComponents());
        }

        [Test]
        public void TestHasComponent()
        {
            var state = new TestState();
            var fooComp = new FooComponent();
            var fooComp2 = new FooComponent();
            state.AddComponent(fooComp);
            Assert.True(state.HasComponent(fooComp));
            Assert.False(state.HasComponent(fooComp2));
            Assert.True(state.HasComponent(typeof (FooComponent)));
            Assert.False(state.HasComponent(typeof (BarComponent)));
            Assert.True(state.HasComponent(c => ((FooComponent) c).Test == "Foo"));
            Assert.False(state.HasComponent(c => ((FooComponent) c).Test == "Bar"));
        }

        [Test]
        public void TestGetComponent()
        {
            var state = new TestState();
            var fooComp = new FooComponent();
            var customFoo = new FooComponent {Test = "NewFoo"};
            var barComp = new BarComponent();
            var customBar = new BarComponent {Test = "NewBar"};
            state.AddComponent(fooComp);
            state.AddComponent(customFoo);
            state.AddComponent(barComp);
            state.AddComponent(customBar);
            Assert.AreEqual(state.GetAllComponents().Count(), 4);
            Assert.AreEqual(state.GetAllComponents(typeof (FooComponent)).Count(), 2);
            
            // We have to do some null checking, as we have both Foo and Bar components
            // in the game state.

            Assert.AreEqual(state.GetAllComponents(c =>
            {
                var f = c as FooComponent;
                return f != null && f.Test == "NewFoo";
            }).Count(), 1);

            Assert.IsEmpty(state.GetAllComponents(c =>
            {
                var f = c as FooComponent;
                return f != null && f.Test == "NewBar";
            }));

            Assert.IsInstanceOf<FooComponent>(state.GetComponent(typeof (FooComponent)));
            
            Assert.AreEqual(state.GetComponent(c =>
            {
                var cf = c as FooComponent;
                return cf != null && cf.Test == "NewFoo";
            }), customFoo);
        }
    }
}
