﻿using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Infrastructure
{
    public interface IGame
    {
        public Game GetGame(int id);
        public IQueryable<Game> GetGames { get; }
        public bool Save(Game game);
        public void Update(Game game);
        public void Delete(Game game);
    }
}
