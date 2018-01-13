package com.disabledtech.winremote.view;

import android.content.Context;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;

import com.disabledtech.winremote.model.WinAction;
import com.disabledtech.winremote.model.WinActionButton;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by admin on 1/13/2018.
 */

public class WinActionViewAdapter extends BaseAdapter
{
	private final Context m_Context;
	private final List<WinActionButton> m_ButtonList;

	public WinActionViewAdapter(Context appContext, List<WinAction> actions)
	{
		this.m_Context = appContext;
		this.m_ButtonList = new ArrayList<>();

		for (WinAction action : actions)
		{
			WinActionButton actionButton = new WinActionButton(m_Context, action);
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
