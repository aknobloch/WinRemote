package com.disabledtech.winremote.view;

import android.content.Context;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;

import com.disabledtech.winremote.model.WinAction;
import com.disabledtech.winremote.model.WinActionButton;

import java.util.ArrayList;
import java.util.List;

/*
FIXME
We should be using an OnItemClickListener set on the containing view in the UI
to provide better encapsulation and coupling. However, this layout contains
a series of buttons, and there is a bug in Android regarding click events.

See https://issuetracker.google.com/issues/36908602#c27
See https://stackoverflow.com/a/2098866
 */
public class WinActionViewAdapter extends BaseAdapter
{
	private final Context m_Context;
	private final List<WinActionButton> m_ButtonList;

	public WinActionViewAdapter(Context appContext, View.OnClickListener buttonListener, List<WinAction> actions)
	{
		this.m_Context = appContext;
		this.m_ButtonList = new ArrayList<>();

		for (WinAction action : actions)
		{
			WinActionButton actionButton = new WinActionButton(m_Context, action);
			actionButton.setOnClickListener(buttonListener);
			m_ButtonList.add(actionButton);
		}
	}

	@Override
	public int getCount()
	{
		return m_ButtonList.size();
	}

	@Override
	public Object getItem(int position)
	{
		return m_ButtonList.get(position);
	}

	@Override
	public long getItemId(int position)
	{
		return m_ButtonList.get(position).getActionID();
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent)
	{
		return m_ButtonList.get(position);
	}
}
