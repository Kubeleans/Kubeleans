namespace Kubeleans.Model
{
    /// <summary>
    /// Represent which runtime the function requires to run
    /// </summary>
    public enum FunctionRuntime
    {
        /// <summary>
        /// Compiled CSharp assembly
        /// </summary>
        CSharp = 0,
        /// <summary>
        /// Roslyn C# Script (.csx)
        /// </summary>
        CSharpScript = 1,
        /// <summary>
        /// ES6 JavaScript based on ChakraCore engine
        /// </summary>
        JavaScript = 2,
        /// <summary>
        /// TypeScript based on ChakraCore engine
        /// </summary>
        TypeScript = 3,
        /// <summary>
        /// C++ 
        /// </summary>
        CPP = 4,
        /// <summary>
        /// Rust
        /// </summary>
        Rust = 5,
        /// <summary>
        /// Go lang
        /// </summary>
        Go = 6
    }
}
