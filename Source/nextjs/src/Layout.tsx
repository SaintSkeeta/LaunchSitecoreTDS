import React from 'react';
import Head from 'next/head';
import {
  Placeholder,
  VisitorIdentification,
  getPublicUrl,
  LayoutServiceData,
} from '@sitecore-jss/sitecore-jss-nextjs';
import Navigation from 'src/Navigation';

// Prefix public assets with a public URL to enable compatibility with Sitecore Experience Editor.
// If you're not supporting the Experience Editor, you can remove this.
const publicUrl = getPublicUrl();

interface LayoutProps {
  layoutData: LayoutServiceData;
}

const Layout = ({ layoutData }: LayoutProps): JSX.Element => {
  const { route } = layoutData.sitecore;

  return (
    <>
      <Head>
        <title>{route?.fields?.pageTitle?.value || 'Page'}</title>
        <link rel="icon" href={`${publicUrl}/favicon.ico`} />
      </Head>

      {/*
        VisitorIdentification is necessary for Sitecore Analytics to determine if the visitor is a robot.
        If Sitecore XP (with xConnect/xDB) is used, this is required or else analytics will not be collected for the JSS app.
        For XM (CMS-only) apps, this should be removed.

        VI detection only runs once for a given analytics ID, so this is not a recurring operation once cookies are established.
      */}
      <VisitorIdentification />

      {
        /*
        TODO: Implement the static rendering calls, like Navigation from Main.cshtml, here.
        */
      }

{
  /*
  TODO: This combines multiple renderings.
  Instead, make this work with the nested container renderings (One Four One.cshtml)
  https://doc.sitecore.com/xp/en/developers/hd/200/sitecore-headless-development/convert-components-from-mvc--c--razor--to-next-js--javascript-react--incrementally.html
  */

}

      <div className="main-content">
        <div className="row topmargin" data-sr>
            <div className="col-md-12 no-padding"><Placeholder name="/main-content/full-row1" rendering={route} /></div>
        </div>

        <div className="container">
            <div className="row" data-sr>
                <div className="col-md-12">
                    <div className="row hero-list">
                        <div className="col-md-3"><Placeholder name="/main-content/full-row2a" rendering={route} /></div>
                        <div className="col-md-3"><Placeholder name="/main-content/full-row2b" rendering={route} /></div>
                        <div className="col-md-3"><Placeholder name="/main-content/full-row2c" rendering={route} /></div>
                        <div className="col-md-3"><Placeholder name="/main-content/full-row2d" rendering={route} /></div>
                    </div>
                </div>
            </div>
            <div className="row" data-sr>
                <div className="col-md-12"><Placeholder name="/main-content/full-row3" rendering={route} /></div>
            </div>
        </div>
      </div>

    </>
  );
};

export default Layout;
