﻿using System.Collections.Generic;
using System.Linq;

namespace TAS.Client.Config.Model
{
    public class ArchiveDirectories
    {
        public readonly List<ArchiveDirectory> Directories;
        private readonly Database.Db _db;

        public ArchiveDirectories(Database.Db db)
        {
            _db = db;
            Directories = db.DbLoadArchiveDirectories<ArchiveDirectory>();
            Directories.ForEach(d => d.IsModified = false);
        }

        public void Save()
        {
            foreach (var dir in Directories.ToList())
            {
                if (dir.IsDeleted)
                {
                    _db.DbDeleteArchiveDirectory(dir);
                    Directories.Remove(dir);
                }
                else
                if (dir.IsNew)
                    _db.DbInsertArchiveDirectory(dir);
                else
                if (dir.IsModified)
                    _db.DbUpdateArchiveDirectory(dir);
            }
        }
    }
}
