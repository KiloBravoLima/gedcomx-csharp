﻿using Gx.Rs.Api;
using Gx.Rs.Api.Util;
using Gx.Source;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FamilySearch.Api
{
    public class UserHistoryState : GedcomxApplicationState<Gx.Gedcomx>
    {
        public UserHistoryState(IRestRequest request, IRestResponse response, IFilterableRestClient client, String accessToken, FamilySearchStateFactory stateFactory)
            : base(request, response, client, accessToken, stateFactory)
        {
        }

        protected override GedcomxApplicationState<Gx.Gedcomx> Clone(IRestRequest request, IRestResponse response, IFilterableRestClient client)
        {
            return new UserHistoryState(request, response, client, this.CurrentAccessToken, (FamilySearchStateFactory)this.stateFactory);
        }

        protected override Gx.Gedcomx LoadEntity(IRestResponse response)
        {
            return response.StatusCode == HttpStatusCode.OK ? response.ToIRestResponse<Gx.Gedcomx>().Data : null;
        }

        public List<SourceDescription> UserHistory
        {
            get
            {
                return Entity == null ? null : Entity.SourceDescriptions;
            }
        }
    }
}
