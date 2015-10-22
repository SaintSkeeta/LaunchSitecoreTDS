define(["sitecore"], function (Sitecore) {

    Sitecore.Commands.LaunchFieldEditor =
    {
        canExecute: function (context) {
            if (!Sitecore.ExperienceEditor.isInMode("edit")) {
                return false;
            }
            return true;
        },
        execute: function (context) {
            context.currentContext.argument = context.button.viewModel.$el[0].accessKey;

            Sitecore.ExperienceEditor.PipelinesUtil.generateRequestProcessor("ExperienceEditor.GenerateFieldEditorUrl", function (response) {
                var DialogUrl = response.responseValue.value;
                var dialogFeatures = "dialogHeight: 680px;dialogWidth: 520px;";
                Sitecore.ExperienceEditor.Dialogs.showModalDialog(DialogUrl, '', dialogFeatures, null);
            }).execute(context);
        }
    };
});