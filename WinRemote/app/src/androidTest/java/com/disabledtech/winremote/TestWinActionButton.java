package com.disabledtech.winremote;

import android.content.Context;
import android.support.test.InstrumentationRegistry;
import android.support.test.runner.AndroidJUnit4;

import com.disabledtech.winremote.model.WinAction;
import com.disabledtech.winremote.model.WinActionButton;

import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;

import java.util.Random;

import static junit.framework.Assert.assertEquals;

@RunWith(AndroidJUnit4.class)
public class TestWinActionButton
{
	@Test
	public void testDisplayName()
	{
		String displayName = "Test Display";
		WinAction action = new WinAction(displayName, 0);

		WinActionButton button = new WinActionButton(InstrumentationRegistry.getTargetContext(), action);
		assertEquals(displayName, button.getText());
		assertEquals(displayName, button.getDisplayName());
	}

	@Test
	public void testGetID()
	{
		int id = new Random().nextInt();
		WinAction action = new WinAction("Test Button", id);

		WinActionButton button = new WinActionButton(InstrumentationRegistry.getTargetContext(), action);
		assertEquals(button.getActionID(), id);
	}

	@Test
	public void testGetAction()
	{
		WinAction action = new WinAction("Test Button", 10);

		WinActionButton button = new WinActionButton(InstrumentationRegistry.getTargetContext(), action);
		assertEquals(button.getWinAction(), action);
	}
}
