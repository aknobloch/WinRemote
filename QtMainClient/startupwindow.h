#ifndef STARTUPWINDOW_H
#define STARTUPWINDOW_H

#include <QMainWindow>

namespace Ui {
class StartupWindow;
}

class StartupWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit StartupWindow(QWidget *parent = 0);
    ~StartupWindow();

private:
    Ui::StartupWindow *ui;
};

#endif // STARTUPWINDOW_H
