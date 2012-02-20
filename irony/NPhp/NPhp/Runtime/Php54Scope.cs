﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPhp.Runtime
{
	public class Php54Scope
	{
		public Php54Runtime Php54Runtime;
		protected Dictionary<string, Php54Var> Variables = new Dictionary<string, Php54Var>();
		public Php54Var[] Arguments;
		public Php54Var ReturnValue = new Php54Var(null);

		static readonly public Php54Scope Methods = new Php54Scope(null);

		public Php54Scope(Php54Runtime Php54Runtime)
		{
			this.Php54Runtime = Php54Runtime;
		}

		public Php54Scope NewScope()
		{
			return new Php54Scope(Php54Runtime);
		}

		public void SetArgumentCount(int Count)
		{
			Arguments = new Php54Var[Count];
		}

		public void SetArgument(int Index, Php54Var Value)
		{
			Arguments[Index] = Value;
		}

		public void LoadArgument(string Name, int Index)
		{
			Variables[Name] = GetArgument(Index);
		}

		public Php54Var GetArgument(int Index)
		{
			return (Index < Arguments.Length) ? Arguments[Index] : new Php54Var(null);
		}

		public void SetReturnValue(Php54Var Value)
		{
			ReturnValue = Value;
		}

		public void SetReturnValueObject(object Value)
		{
			ReturnValue = new Php54Var(Value);
		}

		public Php54Var GetReturnValue()
		{
			return ReturnValue;
		}

		public void CallFunctionByName(string Name)
		{
			Php54Runtime.FunctionScope.Functions[Name](this);
		}

		public Php54Var GetVariable(string Name)
		{
			if (!Variables.ContainsKey(Name)) Variables[Name] = new Php54Var(null);
			return Variables[Name];
		}
	}
}