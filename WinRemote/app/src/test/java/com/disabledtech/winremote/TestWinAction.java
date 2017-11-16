package com.disabledtech.winremote;

import com.disabledtech.winremote.model.WinAction;

import org.junit.Before;
import org.junit.Test;

import static junit.framework.Assert.assertEquals;

public class TestWinAction
{
	@Test
	public void testGetID()
	{
		WinAction action = new WinAction("Button Display", 50);
		assertEquals(action.getID(), 50);
	}
}
