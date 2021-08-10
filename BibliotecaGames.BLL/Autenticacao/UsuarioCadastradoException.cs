using System;
using System.Runtime.Serialization;

namespace BibliotecaGames.BLL.Autenticacao
{
	[Serializable]
	internal class UsuarioCadastradoException : Exception
	{
		public UsuarioCadastradoException()
		{
		}

		public UsuarioCadastradoException(string message) : base(message)
		{
		}

		public UsuarioCadastradoException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected UsuarioCadastradoException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}