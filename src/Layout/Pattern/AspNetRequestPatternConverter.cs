#region Copyright & License
//
// Copyright 2001-2006 The Apache Software Foundation
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion

// .NET Compact Framework 1.0 has no support for ASP.NET
// SSCLI 1.0 has no support for ASP.NET
#if !NETCF && !SSCLI 

using System.IO;
using System.Web;
using log4net.Core;
using log4net.Util;

namespace log4net.Layout.Pattern
{
	/// <summary>
	/// Converter for items in the ASP.Net Cache.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Outputs an item from the <see cref="HttpRuntime.Cache" />.
	/// </para>
	/// </remarks>
	/// <author>Ron Grabowski</author>
	internal sealed class AspNetRequestPatternConverter : AspNetPatternLayoutConverter
	{
		/// <summary>
		/// Write the ASP.Net Cache item to the output
		/// </summary>
		/// <param name="writer"><see cref="TextWriter" /> that will receive the formatted result.</param>
		/// <param name="loggingEvent">The <see cref="LoggingEvent" /> on which the pattern converter should be executed.</param>
		/// <param name="httpContext">The <see cref="HttpContext" /> under which the ASP.Net request is running.</param>
		/// <remarks>
		/// <para>
		/// Writes out the value of a named property. The property name
		/// should be set in the <see cref="log4net.Util.PatternConverter.Option"/>
		/// property.
		/// </para>
		/// </remarks>
		protected override void Convert(TextWriter writer, LoggingEvent loggingEvent, HttpContext httpContext)
		{
			if (httpContext.Request != null)
			{
				if (Option != null)
				{
					WriteObject(writer, loggingEvent.Repository, httpContext.Request.Params[Option]);
				}
				else
				{
					WriteObject(writer, loggingEvent.Repository, httpContext.Request.Params);
				}
			}
			else
			{
				writer.Write(SystemInfo.NotAvailableText);
			}
		}
	}
}

#endif