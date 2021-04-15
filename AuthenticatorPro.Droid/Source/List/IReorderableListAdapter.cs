﻿namespace AuthenticatorPro.Droid.List
{
    internal interface IReorderableListAdapter
    {
        public void MoveItemView(int oldPosition, int newPosition);
        public void NotifyMovementStarted();
        public void NotifyMovementFinished();
    }
}