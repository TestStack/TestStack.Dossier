using Ploeh.AutoFixture.Kernel;

namespace NTestDataBuilder
{
    /// <summary>
    /// Dummy <see cref="ISpecimenContext"/>.
    /// </summary>
    public class DummyContext : ISpecimenContext
    {
        /// <inerhitdoc />
        public object Resolve(object request)
        {
            return null;
        }
    }
}
