﻿/*   Copyright 2009 - 2010 Marcus Bratton

     Licensed under the Apache License, Version 2.0 (the "License");
     you may not use this file except in compliance with the License.
     You may obtain a copy of the License at

     http://www.apache.org/licenses/LICENSE-2.0

     Unless required by applicable law or agreed to in writing, software
     distributed under the License is distributed on an "AS IS" BASIS,
     WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
     See the License for the specific language governing permissions and
     limitations under the License.
*/

using System;
using Siege.ServiceLocation.RegistrationTemplates;
using Siege.ServiceLocation.RegistrationTemplates.OpenGenerics;

namespace Siege.ServiceLocation.Registrations.OpenGenerics
{
    public class OpenGenericRegistration : Registration, IOpenGenericRegistration
    {
        private readonly Type mapsFromType;
        protected Type mapsToType;

        public OpenGenericRegistration(Type mapsFromType)
        {
            if (!mapsFromType.IsGenericType) throw new Exception("Type: " + mapsFromType + " is not a generic type.");
            this.mapsFromType = mapsFromType;
        }

        public void MapsTo(Type mapsToType)
        {
            this.mapsToType = mapsToType;
        }

        public override object GetMappedTo()
        {
            return GetMappedToType();
        }

        public override Type GetMappedToType()
        {
            return mapsToType;
        }

        protected override IActivationStrategy GetActivationStrategy()
        {
            throw new NotImplementedException();
        }

        public override IRegistrationTemplate GetRegistrationTemplate()
        {
            return new OpenGenericRegistrationTemplate();
        }

        public override Type GetMappedFromType()
        {
            return mapsFromType;
        }

        IOpenGenericRegistration IOpenGenericRegistration.Then(Type type)
        {
            if (!type.IsGenericType) throw new Exception("Type: " + type + " is not a generic type.");

            MapsTo(type);

            return this;
        }
    }
}