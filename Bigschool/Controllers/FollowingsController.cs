﻿using Bigschool.DTOs;
using Bigschool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bigschool.Controllers
{
    //xong rồi nha
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;
        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FolloweeId == userId && f.FolloweeId == followingDto.FolloweeId))
                return BadRequest("Following already exists!");

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId
            };



            _dbContext.Followings.Add(following);
            _dbContext.SaveChanges();

            following = _dbContext.Followings
                .Where(x => x.FolloweeId == followingDto.FolloweeId && x.FollowerId == userId)
                .Include(x => x.Followee)
                .Include(x => x.Follower).SingleOrDefault();

            
            _dbContext.SaveChanges();


            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult UnFollow(string followeeId, string followerId)
        {
            var follow = _dbContext.Followings
                .Where(x => x.FolloweeId == followeeId && x.FollowerId == followerId)
                .Include(x => x.Followee)
                .Include(x => x.Follower).SingleOrDefault();

            

            _dbContext.Followings.Remove(follow);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
