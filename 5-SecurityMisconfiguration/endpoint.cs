// Broken Endpoint
[HttpGet]
public ActionResult GetUserDetails(int userId)
{
    var user = _userRepository.GetUserById(userId);
    return Json(user, JsonRequestBehavior.AllowGet);
}



// Fixed Endpoint
[HttpGet]
[Authorize]
public ActionResult GetUserDetails(int userId)
{
    var currentUserId = User.Identity.GetUserId();
    if (currentUserId != userId.ToString())
    {
        return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
    }

    var user = _userRepository.GetUserById(userId);
    return Json(new { Name = user.Name, Email = user.Email }, JsonRequestBehavior.AllowGet);
}
