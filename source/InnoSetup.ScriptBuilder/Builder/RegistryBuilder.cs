﻿namespace InnoSetup.ScriptBuilder
{
    using System.Collections.Generic;
    using Model.FileSection;
    using Model.RegistrySection;

    public class RegistryBuilder : ParameterSectionBuilderBase<RegistryBuilder, RegistryEntry>, IRegistryBuilder
    {
        public override string SectionName => "Registry";

        public RegistryBuilder CreateEntry(RegistryKeys root, string subkey)
        {
            CreateEntryInternal();
            Root(root);
            Subkey(subkey);

            return this;
        }

        public RegistryBuilder ValueType(ValueTypes value) => SetPropertyValue(value);

        public RegistryBuilder ValueName(string value) => SetPropertyValue(value);

        public RegistryBuilder ValueData(string value) => SetPropertyValue(value);

        public RegistryBuilder Flags(RegistryFlags value) => SetPropertyValue(value);
        public RegistryBuilder Components(string value) => SetPropertyValue(value);
        public RegistryBuilder Tasks(string value) => SetPropertyValue(value);

        public RegistryBuilder AddPermission(Sids group, Permissions permission)
        {
            Data.Permissions ??= new List<GroupPermission>();
            Data.Permissions.Add(new GroupPermission(group, permission));
            return this;
        }

        private RegistryBuilder Root(RegistryKeys value) => SetPropertyValue(value);

        private RegistryBuilder Subkey(string value) => SetPropertyValue(value);
    }
}