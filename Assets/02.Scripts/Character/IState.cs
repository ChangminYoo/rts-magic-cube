public interface IState
{
	public enum State
	{
		Idle,
		Run,
		Dead,
		Patrol,
		Stun
	}

	public void ChangeState(State nextState);
	public bool IsDead();
	public void Move();
}
