Placeholder Settings Rules
--
To install, use the Sitecore package installation wizard to install the 
"Placeholder Settings Rules.zip" package.  This will create the required
items in Sitecore, place the .config file in the App_Config\Include
directory, and place the DLL in your site's bin folder.

One final step - you must add the Placeholder Settings Rules template
to the list of base templates for Sitecore's Placeholder template.
This is located at /sitecore/Templates/System/Layout/Placeholder.

Once installed, you should see a new "Allowed Controls Rules" field
when editing a placeholder settings item.  These rules get applied
on top of any renderings already specified in the Allowed Controls
field and may add or remove items from the list based on some custom
conditions.

When editing a rule on a placeholder settings item, you will see
three new conditions:

	1) where the total number of renderings in the placeholder
	   [compares to] [number].

	2) where the number of renderings [rendering] in the placeholder
	   [compares to] [number].

	3) where the number of sublayouts [sublayout] in the placeholder
	   [compares to] [number].

Note - the first condition uses the term "renderings" to mean ALL types
of renderings while the second condition uses it to mean any rendering
located under /Layouts/Renderings (as opposed to the third condition
which allows you to select sublayouts from /Layouts/Sublayouts).

Three new actions are also availble for placeholder settings rules:

	1) [allow or do not allow] rendering [a rendering].

	2) [allow or do not allow] sublayout [a sublayout].

	3) do not allow any renderings.

Again, in the case of the third action - "renderings" refers to ALL types
of renderings (including sublayouts).

These conditions and actions can be used to limit the options presented
whenever a user attempts to add a component to a placeholder in the
unified page editor.  For example:

	where the total number of renderings in the placeholder
	is greater than or equal to 4
	--
	do not allow any renderings

The above rule would allow any 4 renderings to be added to the placeholder
(subject to limits set in Allowed Controls or by other rules), but then
no more would be allowed.

	where the number of sublayouts My Sublayout in the placeholder
	is greater than or equal to 1
	--
	do not allow sublayout My Sublayout

Assuming "My Sublayout" was in the Allowed Controls, this rule would allow
only one My Sublayout to exist in the placeholder.  After that, the option
would no longer be presented.

These conditions and actions can even be combined into multiple rules - to
only allow one rendering type if another already exists, but still enforce
a maximum number of each for example.

If you have any questions or suggestions about usage of this module, or 
maybe just want to talk to me about the code or something - I can be reached
on Twitter @williamsk000.
