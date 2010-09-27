﻿/* Copyright 2010 10gen Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MongoDB.BsonLibrary;
using MongoDB.CSharpDriver;

namespace MongoDB.CSharpDriver.Builders {
    public static class OrderBy {
        #region public static methods
        public static OrderByBuilder Ascending(
            params string[] names
        ) {
            var builder = new OrderByBuilder();
            builder.Ascending(names);
            return builder;
        }

        public static OrderByBuilder Descending(
            params string[] names
        ) {
            var builder = new OrderByBuilder();
            builder.Descending(names);
            return builder;
        }
        #endregion
    }

    public class OrderByBuilder {
        #region private fields
        private BsonDocument document;
        #endregion

        #region constructors
        public OrderByBuilder() {
            document = new BsonDocument();
        }
        #endregion

        #region public operators
        public static implicit operator BsonDocument(
            OrderByBuilder builder
        ) {
            return builder.document;
        }
        #endregion

        #region public methods
        public OrderByBuilder Ascending(
            params string[] names
        ) {
            foreach (var name in names) {
                document.Add(name, 1);
            }
            return this;
        }

        public OrderByBuilder Descending(
            params string[] names
        ) {
            foreach (var name in names) {
                document.Add(name, -1);
            }
            return this;
        }
        #endregion
    }
}