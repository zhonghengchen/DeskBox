using DeskBox.Contracts;
using DeskBox.Controls.WidgetContents;
using DeskBox.Models;

namespace DeskBox.Services;

/// <summary>
/// Standalone calendar entry point. The existing Glance calendar surface is
/// reused so calendar rendering and traditional-calendar behavior stay in one place.
/// </summary>
internal sealed class CalendarWidgetContentProvider : IWidgetContentProvider
{
    public WidgetKind WidgetKind => WidgetKind.Calendar;
    public bool CanCreateDetachedContent => true;

    public IWidgetContent CreateDetachedContent(WidgetConfig config, WidgetContentProviderContext context)
    {
        return new GlanceWidgetContentAdapter(
            config,
            context.LocalizationService,
            calendarSource: new LocalCalendarPresentationSource(),
            settingsService: context.SettingsService);
    }
}
