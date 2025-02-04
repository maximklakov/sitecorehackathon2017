﻿using System;
using DropboxProvider.Models;
using Sitecore.DataExchange.Attributes;
using Sitecore.DataExchange.Converters.PipelineSteps;
using Sitecore.DataExchange.Models;
using Sitecore.DataExchange.Plugins;
using Sitecore.DataExchange.Repositories;
using Sitecore.Services.Core.Model;

namespace DropboxProvider.Converters
{
    [SupportedIds("{3CCD110E-DD01-4EEB-81A3-AFCE38EF93B0}", "{A9D3C449-B9E3-44C1-B153-CAEC25C54444}")]
    public class ReadDropboxStepConverter : BasePipelineStepConverter
    {
        
        public ReadDropboxStepConverter(IItemModelRepository repository) : base(repository)
        {
        }
        protected override void AddPlugins(ItemModel source, PipelineStep pipelineStep)
        {
            AddEndpointSettings(source, pipelineStep);
        }
        private void AddEndpointSettings(ItemModel source, PipelineStep pipelineStep)
        {
            var settings = new EndpointSettings();
            var endpointFrom = base.ConvertReferenceToModel<Endpoint>(source, DropboxStepItemModel.EndpointFrom);
            if (endpointFrom != null)
            {
                settings.EndpointFrom = endpointFrom;
            }
            pipelineStep.AddPlugin(settings);
        }
    }
}
