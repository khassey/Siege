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
using System.Collections.Generic;
using Siege.ServiceLocation.Stores.UseCases;

namespace Siege.ServiceLocation.UseCases.Managers
{
    public class DefaultUseCaseManager : IUseCaseManager
    {
        private readonly DefaultUseCaseList useCases = new DefaultUseCaseList();

        public void Add(IUseCase useCase)
        {
            useCases.Add(useCase.GetBaseBindingType(), useCase);
        }

        public List<IUseCase> GetUseCasesForType(Type type)
        {
            return new List<IUseCase> { useCases.GetUseCaseForType(type) };
        }

        public bool Contains(Type type)
        {
            return useCases.Contains(type);
        }
    }
}