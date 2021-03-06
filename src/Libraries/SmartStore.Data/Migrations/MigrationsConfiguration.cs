﻿namespace SmartStore.Data.Migrations
{
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;
	using Setup;
	using SmartStore.Utilities;
	using SmartStore.Core.Domain.Media;
	using Core.Domain.Configuration;
	using SmartStore.Core.Domain.Customers;
	using SmartStore.Core.Domain.Seo;

	public sealed class MigrationsConfiguration : DbMigrationsConfiguration<SmartObjectContext>
	{
		public MigrationsConfiguration()
		{
			AutomaticMigrationsEnabled = false;
			AutomaticMigrationDataLossAllowed = true;
			ContextKey = "SmartStore.Core";
		}

		public void SeedDatabase(SmartObjectContext context)
		{
			Seed(context);
		}

		protected override void Seed(SmartObjectContext context)
		{
			context.MigrateLocaleResources(MigrateLocaleResources);
			MigrateSettings(context);

			context.SaveChanges();
        }

		public void MigrateSettings(SmartObjectContext context)
		{
			// SeoSettings.RedirectLegacyTopicUrls should be true when migrating (it is false by default after fresh install)
			var name = TypeHelper.NameOf<SeoSettings>(y => y.RedirectLegacyTopicUrls, true);
			context.MigrateSettings(x => x.Add(name, true));
		}

		public void MigrateLocaleResources(LocaleResourcesBuilder builder)
		{
			
		}
	}
}
